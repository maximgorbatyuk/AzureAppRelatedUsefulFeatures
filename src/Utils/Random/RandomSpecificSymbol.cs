﻿namespace Utils.Random
{
    public record RandomSpecificSymbol : RandomStringBase
    {
        public RandomSpecificSymbol(int length)
            : base(length)
        {
        }

        protected override string Chars => "!$%^&*";
    }
}