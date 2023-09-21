using UnityEngine;

public static class Translator
{
    static int langIndex=-1; // индекс языка: -1-еще не инициализирован, 0-англ, 1 - русский и т.д.
  
    public static string Translate(string text_)
    {
        if(langIndex==-1) // начальная инициализация индекса языка при первом вызове
        {
            switch(Application.systemLanguage.ToString())
            {
                case "English": langIndex=0; break;
                case "Russian": langIndex=1; break;
                case "Turkish": langIndex=2; break;
                    // продолжить для других языков ....
            }
        }
      
        for(int i=0;i<labels.GetLength(0);i++)
        {
            if(text_==labels[i,0]) return labels[i,langIndex];
        }
        return text_;
    }
  
  
    // здесь будут все наши тексты
    static string [,] labels=
    {
        {
            "win ", // англ.
            "пройди ",  // русс.
            "kazanç"
        },
        {
            " level",
            " уровень",
            " seviye"
        },
        {
            "LEVEL ",
            "УРОВЕНЬ ",
            "SEVİYE "
        },
        {
            "energy is over",
            "энергия закончилась",
            "enerji bitti"
        },
        {
            "life is over",
            "убит",
            "Hayat bitti"
        },
        {
            "I don't know why you are over",
            "Не знаю почему ты проиграл",
            "Neden bittiğini bilmiyorum"
        },
        {
            "You win",
            "Ты победил",
            "Sen kazandın"
        },
        {
          "YOU WIN",
          "Ты победил",
          "SEN KAZANDIN"
        },
        {
          "GAME OVER",
          "Попробуй снова",
          "OYUN BİTTİ"
        },
        {
          "COMBO",
          "комбо",
          "KOMBO"
        },
        {
            "Health",
            "Здоровье",
            "Sağlık"
        },
        {
            "Attack",
            "Атака",
            "Saldırı"
        },
        {
            "Balls",
            "Кол-во шаров",
            "Toplar"
        },
        {
            "Line",
            "длина прицела",
            "Astar"
        },
        {
            "UPGRADE",
            "Улучшить за",
            "GÜNCELLEME"
        },
        {
            "LEGEND",
            "Легенд.",
            "EFSANE"
        },
        {
            "GUNS",
            "Снаряды",
            "SİLAHLAR"
        },
        {
            "SHOP",
            "Магазин",
            "MAĞAZA"
        },
        {
            "SKINS",
            "Скины",
            "DERİ"
        },
        {
            "Black Hole Ball",
            "Черная дыра",
            "Kara Delik Topu"
        },
        {
            "Bomb Ball",
            "бомба",
            "Bomba Topu"
        },
        {
            "Fire Ball",
            "Огненный мяч",
            "Ateş Topu"
        },
        {
            "Ice Ball",
            "Лед",
            "Buz topu"
        },
        {
            "Insta Kill",
            "Мяч убийца",
            "Katil"
        },
        {
            "Laser Cross Ball",
            "Лазер",
            "lazer"
        },
        {
            "Laser Horizontal Ball",
            "Лазер",
            "lazer"
        },
        {
            "Laser Vertical Ball",
            "Лазер",
            "lazer"
        },
        {
            "Poison Ball",
            "Отрава",
            "Zehir"
        },
        {
            "Rocket Ball",
            "Ракета",
            "Roket"
        },
        {
            "Black Hole Combo",
            "Комбо черная дыра",
            "Kara Delik Kombinasyonu"
        },
        {
            "Bomb Combo",
            "Комбо бомба",
            "Bomba Kombinasyonu"
        },
        {
            "Insta Kill Combo",
            "Комбо киллер",
            "öldürücü kombinasyon"
        },
        {
            "Laser Cross Combo",
            "Комбо лазер",
            "Lazer Kombinasyonu"
        },
        {
            "Laser Horizontal Combo",
            "Комбо лазер",
            "Lazer Kombinasyonu"
        },
        {
            "Laser Vertical Combo",
            "Комбо лазер",
            "Lazer Kombinasyonu"
        },
        {
            "Poison Combo",
            "Комбо отрава",
            "Zehir Kombinasyonu"
        },
        {
            "Rocket Combo",
            "Комбо ракета",
            "Roket Kombosu"
        },
        {
            "Discount Combo Buff",
            "Меньше ударов для старта комбо",
            "İndirim Kombo Takviyesi"
        },
        {
            "Double Combo Buff",
            "Комбо аттака два раза",
            "Çift Kombo Takviyesi"
        },
        {
            "Increased Count Combo Buff",
            "Комбо считается быстрее",
            "Artırılmış Sayılı Kombo Takviyesi"
        },
        {
            " buy",
            " купить",
            " satın almak"
        },
        {
            "Block",
            "Блок",
            "Engellemek"
        },
        {
            "Can't burn",
            "Не горю",
            "Yakamıyorum"
        },
        {
            " Lev.",
            " Ур.",
            " Sev."
        },
        {
            "WAVE",
            "ВОЛНА",
            "DALGA"
        }
                
        // ...... ну и т.д., если языков больше, то в каждом блоке будет больше строчек
    };
    
}