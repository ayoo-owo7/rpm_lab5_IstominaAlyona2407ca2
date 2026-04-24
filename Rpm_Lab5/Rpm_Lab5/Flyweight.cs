using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpm_Lab5
{
    public interface IFlyweight
    {
        void Draw(int positionX, int positionY);
    }

    public class Character : IFlyweight
    {
        private char _symbol;
        private string _font;
        private int _fontSize;

        public Character(char symbol, string font, int fontSize)
        {
            _symbol = symbol;
            _font = font;
            _fontSize = fontSize;
        }

        public void Draw(int positionX, int positionY)
        {
            Console.WriteLine($"Символ '{_symbol}' [{_font}, {_fontSize}px] отрисован в: ({positionX}, {positionY})");
        }
    }

    public class CharacterFactory
    {
        private Dictionary<string, Character> _characters = new Dictionary<string, Character>();

        public Character GetCharacter(char symbol, string font, int fontSize)
        {
            string key = $"{symbol}_{font}_{fontSize}";

            if (!_characters.ContainsKey(key))
            {
                _characters[key] = new Character(symbol, font, fontSize);
                Console.WriteLine($"[Flyweight] Creating new character: {key}");
            }
            else
            {
                Console.WriteLine($"[Flyweight] Reusing existing character: {key}");
            }

            return _characters[key];
        }

        public int GetCount() => _characters.Count;
    }
}
