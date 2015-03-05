using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten
{
    public class Parent
    {
        public String FName, LName, PName, Phone;

        public Parent(String fName, String lName, String pName, String phone)
        {
            FName = fName;
            LName = lName;
            PName = pName;
            Phone = phone;
        }
    }

    public class Child
    {
        public UInt32 ID;
        public String FName, LName, PName, Address, Group;
        public DateTime Birth;
        public Parent Mother, Father;

        public Child(UInt32 id, String fName, String lName, String pName, DateTime birth, String address, String group, Parent mother, Parent father)
        {
            ID = id;
            FName = fName;
            LName = lName;
            PName = pName;
            Birth = birth;
            Address = address;
            Group = group;
            Mother = mother;
            Father = father;
        }

        public Child(Child c)
        {
            ID = c.ID;
            FName = c.FName;
            LName = c.LName;
            PName = c.PName;
            Birth = c.Birth;
            Address = c.Address;
            Group = c.Group;
            Mother = c.Mother;
            Father = c.Father;
        }
    }
}
