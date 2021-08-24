using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//The app is Amdocs
namespace Ex04.Menus.Interfaces
{

     public interface IMainMenuObserver
     {
          void ReportOption(string i_Option);
     }

     public class MainMenu // Employee
     {
          private readonly List<IMainMenuObserver> m_MainMenuObserver = new List<IMainMenuObserver>();
          private string input = null;
          private StringBuilder stringBuilder = new StringBuilder();

          public void AttachObserver(IMainMenuObserver i_MainMenuObserver)
          {
               m_MainMenuObserver.Add(i_MainMenuObserver);
          }

          public void DetachObserver(IMainMenuObserver i_MainMenuObserver)
          {
               m_MainMenuObserver.Remove(i_MainMenuObserver);
          }

          private readonly List<string> m_MainMenuMessages = new List<string>();

          private const string m_HeadLine = "Main Delegates";
          private const string m_ExitMessage = "0 - Exit\n";
          private const string m_SelectMessage = "Please select option:";

          public MainMenu()
          {
               m_MainMenuMessages.Add("Version and Spaces");
               m_MainMenuMessages.Add("Show Date/Time");
               int i = 1;
               stringBuilder.Append(m_HeadLine);
               stringBuilder.Append("\n");
               foreach (string message in m_MainMenuMessages)
               {
                    stringBuilder.Append(i);
                    stringBuilder.Append(" - ");
                    stringBuilder.Append(message);
                    stringBuilder.Append("\n");
                    i++;
               }
               stringBuilder.Append(m_ExitMessage);
               stringBuilder.Append("\n\n");
               stringBuilder.Append(m_SelectMessage);
               stringBuilder.Append("\n");
          }

          public void show()
          {

               while (input != "0")
               {
                    Console.Clear(); //maybe
                    Console.Write(stringBuilder.ToString());
                    input = Console.ReadLine();
                    if (checkInput())
                    {
                         notifyMainMenuListeners();
                    }
                    else
                    {
                         throw new System.ArgumentException();
                    }
               }
          }

          private bool checkInput()
          {
               bool InputValidation = true; // TEST

               return InputValidation;
          }

          private void notifyMainMenuListeners()
          {
               foreach (IMainMenuObserver observer in m_MainMenuObserver)
               {
                    observer.ReportOption(input);
               }
          }

     }
}
