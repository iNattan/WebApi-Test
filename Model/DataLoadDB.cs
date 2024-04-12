using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class DataLoadDB : DataLoadBase {

    public override List<T> Load<T>(string local){
        local = local + ".csv";
        if (!File.Exists(local))
            throw new ArgumentException(local);
        
        using (var reader = new StreamReader(local))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<T>().ToList();
        }
    }
}