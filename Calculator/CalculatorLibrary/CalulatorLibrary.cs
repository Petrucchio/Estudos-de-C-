using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            //create the json --------------------------------------------
            StreamWriter logFile = File.CreateText("Calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
            //create the log --------------------------------------------
            //StreamWriter logFile = File.CreateText("calculator.log");
            //Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            //Trace.AutoFlush = true;
            //Trace.WriteLine("Starting Calculator Log");
            //Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
        }
        public double DoOperation(double num1, double num2, String op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");
            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    //Trace.WriteLine(String.Format($"{num1} + {num2} = {result}"));//log
                    writer.WriteValue("Add");//json
                    break;
                case "s":
                    result = num1 - num2;
                    //Trace.WriteLine(String.Format($"{num1} - {num2} = {result}"));//log
                    writer.WriteValue("Subtract");//json
                    break;
                case "m":
                    result = num1 * num2;
                    //Trace.WriteLine(String.Format($"{num1} * {num2} = {result}"));//log
                    writer.WriteValue("Multiply");//json
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        //Trace.WriteLine(String.Format($"{num1} / {num2} = {result}"));//log
                        writer.WriteValue("Divide");//json
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            writer.WritePropertyName("Result");//json
            writer.WriteValue(result);//json
            writer.WriteEndObject();//json
            return result;
        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
