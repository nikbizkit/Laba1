namespace Lab_7
{
    public class DepartmentEmployees
    {
        public int EmployeeID;
        public int DepartmentID;

        public DepartmentEmployees(int employeeId, int departmentId)
        {
            EmployeeID = employeeId;
            DepartmentID = departmentId;
        }

        public override string ToString()
        {
            return string.Format("{{ DepartmentEmployees EmployeeID: {0}, DepartmentID: {1} }}", EmployeeID, DepartmentID);
        }
    }
}