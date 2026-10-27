using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab.Part02.Reports;

public abstract class ReportExporter
{
    //public Export => becouase i need to call it inside main so i don't making it protected 
    //virtual not abstract ==> so any class inherit it can making override
    public virtual void Export(string path)
    {
        var rows = Load();
        if (!Validate(rows))
            throw new InvalidOperationException("Invalid data");
        var content = Format(rows);
        Save(path, content);
    }

    protected virtual List<string[]> Load() =>
  [
      ["Id", "Name"],
        ["1", "Keyboard"],
        ["2", "Mouse"]
  ];

    protected  virtual bool Validate(List<string[]> rows) =>
      rows.Count > 1 && rows[0].Length > 0;


    protected virtual void Save(string path, string content) =>
      File.WriteAllText(path, content);

    public abstract string Format(List<string[]> rows);


}
