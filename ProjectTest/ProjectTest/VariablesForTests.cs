using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest
{
    class VariablesForTests
    {
        public static string expectedErrorText { get; set; } = "Не удалось войти в аккаунт";
        public static string email { get; set; } = "zaraznaya.pochta@gmail.com";
        public static string searchQuery { get; set; } = "some test data";
        public static int linkNum { get; set; } = 9; // 1-first, 5-second, 6-third ....
        public static int tabNum { get; set; } = 5;
    }
}
