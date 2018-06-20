using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;

            Dictionary<string,List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string,List<string>> departments = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Output")
            {
                var patientData = input.Split();
                
                    var department = patientData[0];
                    var doctor = patientData[1] + " " + patientData[2];
                    var patient = patientData[3];
                    if (!departments.ContainsKey(department))
                    {
                        departments.Add(department,new List<string>());
                    }
                    departments[department].Add(patient);
                    if (!doctors.ContainsKey(doctor))
                    {
                        doctors.Add(doctor,new List<string>());
                    }
                    doctors[doctor].Add(patient);                              
            }
            while ((input = Console.ReadLine()) != "End")
            {
                var splitCommand = input.Split();
                if (splitCommand.Length == 1)
                {
                    foreach (var patient in departments[input])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    int roonMumber = 0;
                    if (int.TryParse(splitCommand[1], out roonMumber))//не е число
                    {
                        var skip = 3 * (roonMumber - 1);
                        foreach (var patient in departments[splitCommand[0]].Skip(skip).Take(3).OrderBy(c => c))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        foreach (var patient in doctors[input].OrderBy(p => p))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
            }
        }
    }
}
