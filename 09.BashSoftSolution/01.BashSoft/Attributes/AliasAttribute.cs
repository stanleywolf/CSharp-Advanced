using System;
using System.Collections.Generic;
using System.Text;
[AttributeUsage(AttributeTargets.Class)]
class AliasAttribute:Attribute
{
    private string name;

    public AliasAttribute(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            this.name = value;
        }
    }

    public override bool Equals(object obj) => this.name.Equals(obj);
}
