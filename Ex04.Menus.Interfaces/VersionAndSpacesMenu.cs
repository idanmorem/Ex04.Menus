using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
     public interface IVersionAndSpacesMenuObserver
     {
          void ReportOption(string i_Option);
     }

     public class VersionAndSpacesMenu // Employee
     {
          private readonly List<IVersionAndSpacesMenuObserver> m_VersionAndSpacesMenuObserver =
               new List<IVersionAndSpacesMenuObserver>();

          private string input = null;

          public void AttachObserver(IVersionAndSpacesMenuObserver i_VersionAndSpacesMenuObserver)
          {
               m_VersionAndSpacesMenuObserver.Add(i_VersionAndSpacesMenuObserver);
          }

          public void DetachObserver(IVersionAndSpacesMenuObserver i_VersionAndSpacesMenuObserver)
          {
               m_VersionAndSpacesMenuObserver.Remove(i_VersionAndSpacesMenuObserver);
          }

          private readonly List<string> m_VersionAndSpacesMenuMessages = new List<string>();
          private const string m_HeadLine = "Version And Spaces";
          public string HeadLine
          {
               get => m_HeadLine;
          }

          private const string m_ExitMessage = "0 - Exit\n";
          public string ExitMessage
          {
               get => m_ExitMessage;
          }

          public VersionAndSpacesMenu()
          {
               m_VersionAndSpacesMenuMessages.Add("Count Spaces");
               m_VersionAndSpacesMenuMessages.Add("Show Version");
          }

          public void show()
          {
               StringBuilder stringBuilder = null;
               int i = 1;
               stringBuilder.Append(HeadLine);
               while (input != "0")
               {
                    Console.Clear();
                    foreach (string message in m_VersionAndSpacesMenuMessages)
                    {
                         stringBuilder.Append(i);
                         stringBuilder.Append(" - ");
                         stringBuilder.Append(message);
                         stringBuilder.Append("\n");
                         i++;
                    }

                    stringBuilder.Append(ExitMessage);
                    input = Console.ReadLine();
                    if (checkInput())
                    {
                         notifyVersionAndSpacesMenuListeners();
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

          private void notifyVersionAndSpacesMenuListeners()
          {
               foreach (IVersionAndSpacesMenuObserver observer in m_VersionAndSpacesMenuObserver)
               {
                    observer.ReportOption(input);
               }
          }
     }
}
