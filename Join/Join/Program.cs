namespace Join
{
	internal class Program
	{
		static void Main(string[] args)
		{

			//Joining Using Method Syntax
			var joinUsingMethodSyntax = Employee.GetAllEmployees()
				.Join(Address.GetAllAddresses(),
				employee => employee.AddressId,
				address => address.ID,
				(employee, Address) => new
				{
					EmployeeName = employee.Name,
					AddressLine = Address.AddressLine
				}).ToList();


			//Joining Using query syntax
			var joinUsingQuerySyntax = (from emp in Employee.GetAllEmployees()
										join add in Address.GetAllAddresses()
										on emp.AddressId equals add.ID
										select new
										{
											EmployeeName = emp.Name,
											AddressLine = add.AddressLine
										}).ToList();
		}
	}
}