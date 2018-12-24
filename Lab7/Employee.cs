namespace Lab_7
{
    public class Employee
    {
        public int ID;
        public string Surname;
        public int DepartmentID;

        public Employee(int id, string surname, int departmentId)
        {
            ID = id;
            Surname = surname;
            DepartmentID = departmentId;
        }

        public override string ToString()
        {
            return string.Format("{{ Employee ID: {0}, Surname: {1}, DepartmentID: {2} }}", ID, Surname, DepartmentID);
        }
    }
}