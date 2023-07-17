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
            "пройди "  // русс.
        },
        {
            " level",
            " уровень"
        },
        {
            "LEVEL ",
            "УРОВЕНЬ "
        },
        {
            "energy is over",
            "энергия закончилась"
        },
        {
            "life is over",
            "убит"
        },
        {
            "I don't know why you are over",
            "Не знаю почему ты проиграл"
        },
        {
            "You win",
            "Ты победил"
        },
        {
          "YOU WIN",
          "Ты победил"
        },
        {
          "GAME OVER",
          "Попробуй снова"
        },
        {
          "COMBO",
          "комбо"
        },
        {
            "Health",
            "Здоровье"
        },
        {
            "Attack",
            "Атака"
        },
        {
            "Balls",
            "Кол-во шаров"
        },
        {
            "Line",
            "длина прицела"
        },
        {
            "UPGRADE",
            "Улучшить за"
        },
        {
            "LEGEND",
            "Легенд."
        },
        {
            "GUNS",
            "Снаряды"
        },
        {
            "SHOP",
            "Магазин"
        },
        {
            "SKINS",
            "Скины"
        },
        {
            "Black Hole Ball",
            "Черная дыра"
        },
        {
            "Bomb Ball",
            "бомба"
        },
        {
            "Fire Ball",
            "Огненный мяч"
        },
        {
            "Ice Ball",
            "Лед"
        },
        {
            "Insta Kill",
            "Мяч убийца"
        },
        {
            "Laser Cross Ball",
            "Лазер"
        },
        {
            "Laser Horizontal Ball",
            "Лазер"
        },
        {
            "Laser Vertical Ball",
            "Лазер"
        },
        {
            "Poison Ball",
            "Отрава"
        },
        {
            "Rocket Ball",
            "Ракета"
        },
        {
            "Black Hole Combo",
            "Комбо черная дыра"
        },
        {
            "Bomb Combo",
            "Комбо бомба"
        },
        {
            "Insta Kill Combo",
            "Комбо киллер"
        },
        {
            "Laser Cross Combo",
            "Комбо лазер"
        },
        {
            "Laser Horizontal Combo",
            "Комбо лазер"
        },
        {
            "Laser Vertical Combo",
            "Комбо лазер"
        },
        {
            "Poison Combo",
            "Комбо отрава"
        },
        {
            "Rocket Combo",
            "Комбо ракета"
        },
        {
            "Discount Combo Buff",
            "Меньше ударов для старта комбо"
        },
        {
            "Double Combo Buff",
            "Комбо аттака выполняется дважды"
        },
        {
            "Increased Count Combo Buff",
            "Комбо считается быстрее"
        },
        {
            " buy",
            " купить"
        }
        
        
        // ...... ну и т.д., если языков больше, то в каждом блоке будет больше строчек
    };
    
}