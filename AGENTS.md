# AGENTS.md

## Project Overview

**Ballz (Brick Breaker)** — гиперказуальная игра в жанре brick-breaker (аналог Ballz), разработанная в Unity. Игрок запускает шары снизу вверх по сетке кирпичей; каждый ход шары летят вверх, отскакивают от кирпичей и возвращаются, после чего кирпичи перемещаются вниз. Целевая платформа — **WebGL для Яндекс.Игр** (интеграция через плагин `PluginYG`).

- Движок: **Unity 2021.3.22f1**
- Используется 2D-физика, UI Toolkit (uGUI), TextMesh Pro (3.0.6), iTween для анимаций.
- Название по папке: `Robots-balls-vs-bricks`.

## Структура проекта

Основной игровой код находится в `Assets/Scripts/`. Посторонние/инструментальные ассеты не относятся к геймплею:

- **TextMesh Pro** — движковый ассет (не редактировать).
- **YandexGame** — сторонний SDK плагина для Яндекс Игр (не редактировать, кроме возможной конфигурации `Assets/YandexGame/WorkingData/InfoYG.asset`).
- **Robot_Main.png**, **Ballz-Brick-Breaker-Unity.gif**, **LICENSE** — документация/графика.

### Иерархия `Assets/Scripts`

| Папка | Назначение |
|---|---|
| `EventManager.cs` | Центральная шина событий (статические C# events) — связующий слой между системами. |
| `LevelManager.cs` | Машина состояний уровня: `BEFOREPLAYABLE` / `PLAYABLE` / `GAMEOVER` / `WIN`. Переключение панелей UI. |
| `ScoreManager.cs`, `WinManager.cs` | Очки, лучший счёт, проверка победы. |
| `GameManager.cs`, `AudioManager.cs` | Глобальный менеджер, аудио. |
| `Gameplay/` | Мужская часть геймплея (см. ниже). |
| `Placing/` | Сеточная система расстановки (Grid, Cell, SceneConfiguration*). |
| `Guns/` | Магазин/панель пушек. |
| `Skins/` | Инвентарь скинов (головы роботов) с реализацией через интерфейсы `IInventory *`. |
| `Scriptable Objects/` | Конфигурации уровней (`LevelSO`), лут (`LootSO`, `LootInChestSO`) и спец-атак (`SpecialAttackSO`, `ComboAttackSO`, `HeroBuffSO`, `BallSO`). |
| `UI/`, `Animation/`, `Data Managing/` | Панели UI, анимации, зётрафии, загрузка/сохранение, пулы объектов. |
| `Interfaces/` | Общие интерфейсы (напр. `IResetToDefaultValues`). |

### Ключевые абстракции геймплея (`Gameplay/`)

- **Шаров (`balls/`)** — базовый `AbstractBall : MonoBehaviour, IBall`. Поведение шаров определяется стратегиями:
  - `AttackBehaviour` (интерфейс `SpecialAttack(...)`) — реализации: `NoAttack`, `FireAttack`, `IceAttack`, `RocketAttack`, `PoisonAttack`, `InstaKillAttack`, `BlackHoleAttack`, `BombAttack`, `Laser*Attack`.
  - `AfterCollisionBehaviour` (интерфейс `BehaviourAfterCollision()`) — `NoDestroy`, `YesDestroy`, `ReturnAfterCollision`.
  - Каждый шар — класс в своей подпапке (например `BombBall`, `LaserBall/`, `BlackHoleBall/`), обычно + `CloneBall`.
- **Падение иммута** — `Balls.cs`, `BallLauncher.cs`: прицеливание (AimLine), запуск, возврат шаров, `ContinuePlaying`.
- **Спец-атаки и комбо** — `SpecialAttacks*` + `Gameplay/Combo/` (`ComboLauncher`, `ComboController`, `ComboAttacks/`). Комбо кратно накапливается через `EventManager.OnComboCounterChanged`. Определяют `ComboAttackEnum`.
- **Кирпичи** — `Bricks/Brick.cs`: машина состояний `IStateBrick` (`Idle`, `Walk`, `Death`, `TakeDamage`, `Attack`, `Freeze`, `Fire`/`Poison`), здоровье (`IHealth`, `HealthBar`), лут через `LootBag`. Спавн — `BrickSpawner`.
- **Герой** — `Hero/Hero.cs`, `HeroStats`, `HeroLevel`, бафы `HeroBuffs`.
- **Валюты/прокачка** — `UpgradeStats.cs`, `Currency/`, `StatsPanel/` (Health, Attack, SightLength, StarterBalls). Энергия — `Energy.cs`.
- **Яндекс-платформа** — интеграция через `YandexGame` (сохранения/линвостраницы/переводы в `UI/Translator.cs`, `PluginYG` WebGL-шаблон).

## Важные особенности

- События объявляются как `public static event Action ...` в `EventManager`, подписка/отписка выполняется в `Awake`/`OnDestroy` (следить за утечками — обязательно отписываться).
- **Сохранения** — `PlayerPrefs` (наивный формат) через `UpgradeStats`, `ScoreManager`, `Saver`. Сеть уже частично есть, JSON через `SavedGame`/`JsonUtility`.
- **Объектные пулы** — `ObjectPool` + `Resources.Load("ComboAttacks/" + comboType)`.
- Использование **iTween** для tween-анимаций (не DoTween).
- `TextController` — централизует цвета/размеры урон-текста.
- Уровни конфигурируются через серию `SceneConfiguration1..24` и `LevelSO`.

## Команды

Проект — чистый Unity без CI/тестов. Тестирование и сборка выполняются в самом редакторе:
- Открой папку проекта в **Unity 2021.3.22f1**.
- Для проверки сборки под WebGL используй меню **Яндекс Игр -> Build** (или стандартный Build для WebGL).
- `git` используется как VCS; коммиты только по явному запросу.

## Правила для агентов

1. **Не редактируй** сторонние/движковый код: `Assets/TextMesh Pro/**`, `Assets/YandexGame/**` (кроме явно требуемой конфигурации).
2. Вся бизнес-логика — в папках `Assets/Scripts/**`. Перед изменениями изучи существующие паттерны (интерфейсы `AttackBehaviour`/`AfterCollisionBehaviour`, машины состояний, событийная модель).
3. При изменении скриптов, которые подписываются **на события** `EventManager`, обязательно добавляй отписку в `OnDestroy`.
4. **Минимизируй магические числа**: проект использует константы и ScriptableObject-конфиги (например `_startCoinsUpgradeValue` в `UpgradeStats`, `TextController`-константы, `ballStartPositionCoordinatesY`).
5. Игровые балансные значения (здоровье, урон, комбо-проценты, лут-коффициенты) вынося в сериализованные поля (`[SerializeField]`) или ScriptableObjects, а не хардкодь.
6. Строки интерфейса (текст панелей) локализуются через `Translator.Translate(...)` — для мультиязычной залпин. Остроправовлено Яндексом.
7. `Debug.Log` в релизе нужно удалять (в коде есть пометки «ВНИМАНИЕ ПЕРЕД РЕЛИЗОМ УДАЛИТЬ»).
8. Комментарии в коде можно оставлять на русском — код частично уже прокомментирован на русском, следуй существующему стилю.

## Note
- Наличие `.meta` файлов критично для Unity — при создании/переименовании скриптов их генерирует Unity, не удаляй.
- `ProjectSettings/` и `UserSettings/` — конфигурация проекта, менять только при осознанном изменении настроек Unity.