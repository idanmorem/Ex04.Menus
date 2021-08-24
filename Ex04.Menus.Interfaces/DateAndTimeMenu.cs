using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
     public interface IDateAndTimeMenuObserver
     {
          void ReportOption(string i_Option);
     }

     public class DateAndTimeMenu // Employee
     {
          private readonly List<IDateAndTimeMenuObserver> m_DateAndTimeMenuObserver =
               new List<IDateAndTimeMenuObserver>();

          private string input = null;

          public void AttachObserver(IDateAndTimeMenuObserver i_DateAndTimeMenuObserver)
          {
               m_DateAndTimeMenuObserver.Add(i_DateAndTimeMenuObserver);
          }

          public void DetachObserver(IDateAndTimeMenuObserver i_DateAndTimeMenuObserver)
          {
               m_DateAndTimeMenuObserver.Remove(i_DateAndTimeMenuObserver);
          }

          private readonly List<string> m_DateAndTimeMenuMessages = new List<string>();
          private const string m_HeadLine = "Show Date/Time";
          public string HeadLine
          {
               get => m_HeadLine;
          }

          private const string m_ExitMessage = "0 - Exit\n";
          public string ExitMessage
          {
               get => m_ExitMessage;
          }

          public DateAndTimeMenu()
          {
               m_DateAndTimeMenuMessages.Add("Show Date");
               m_DateAndTimeMenuMessages.Add("Show Time");
          }

          public void show()
          {
               StringBuilder stringBuilder = null;
               int i = 1;
               stringBuilder.Append(HeadLine);
               while (input != "0")
               {
                    Console.Clear();
                    foreach (string message in m_DateAndTimeMenuMessages)
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
                         notifyDateAndTimeMenuListeners();
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

          private void notifyDateAndTimeMenuListeners()
          {
               foreach (IDateAndTimeMenuObserver observer in m_DateAndTimeMenuObserver)
               {
                    observer.ReportOption(input);
               }
          }
     }
}
