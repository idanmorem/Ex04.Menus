using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
     class Program
     {
          public static void Main()
          {
               Ex04.Menus.Interfaces.MainMenu mainMenu = new Ex04.Menus.Interfaces.MainMenu();
               mainMenu.show();
          }
     }
}
