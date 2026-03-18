using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    public class CharacterFactory // Flyweight
    {
        private Dictionary<string, Character> _characters = new();
        public Character GetCharacter(char symbol, string font, int fontsize)
        {
            //формируем строковый ключ для поиска по словарю
            string key = $"{symbol}_{font}_{fontsize}";
            if (!_characters.ContainsKey(key))
            {
                _characters[key] = new Character(symbol, font, fontsize);
                Console.WriteLine($"Creating new character: {key}");
            }
            return _characters[key];
        }
        public int GetCount() => _characters.Count;
    }
}
