using Application.Common.Persistence.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Sql.Repository;

public class ZoneRepository: IZoneRepository
{
    private readonly DbContext _context;

    public ZoneRepository(DbContext context)
    {
        _context = context;
    }

    #region SAMPLE

    //Execute – an extension method that we use to execute a command one or multiple times and return the number of affected rows

    //Query – with this extension method we can execute a query and map the result

    //QueryFirst –  it executes a query and maps the first result

    //QueryFirstOrDefault – we use this method to execute a query and map the first result, or a default value if the sequence contains no elements

    //QuerySingle – an extension method that can execute a query and map the result.  It throws an exception if there is not exactly one element in the sequence

    //QuerySingleOrDefault – executes a query and maps the result, or a default value if the sequence is empty.It throws an exception if there is more than one element in the sequence

    //QueryMultiple – an extension method that executes multiple queries within the same command and map results

    //public async Task<IEnumerable<Company>> GetCompanies()
    //{
    //    var query = "SELECT * FROM Companies";
    //    using (var connection = _context.CreateConnection())
    //    {
    //        var companies = await connection.QueryAsync<Company>(query);
    //        return companies.ToList();
    //    }
    //}

    /// <summary>
    /// Use parameters with dapper
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public async Task<Company> GetCompany(int id)
    //{
    //    var query = "SELECT * FROM Companies WHERE Id = @Id";
    //    using (var connection = _context.CreateConnection())
    //    {
    //        var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
    //        return company;
    //    }
    //}


    /// <summary>
    /// Dynamic parameters with dapper
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public async Task CreateCompany(CompanyForCreationDto company)
    //{
    //    var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)";
    //    var parameters = new DynamicParameters();
    //    parameters.Add("Name", company.Name, DbType.String);
    //    parameters.Add("Address", company.Address, DbType.String);
    //    parameters.Add("Country", company.Country, DbType.String);
    //    using (var connection = _context.CreateConnection())
    //    {
    //        await connection.ExecuteAsync(query, parameters);
    //    }
    //}

    /// <summary>
    /// Execute and get data return
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public async Task<Company> CreateCompany(CompanyForCreationDto company)
    //{
    //    var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)" +
    //        "SELECT CAST(SCOPE_IDENTITY() as int)";
    //    var parameters = new DynamicParameters();
    //    parameters.Add("Name", company.Name, DbType.String);
    //    parameters.Add("Address", company.Address, DbType.String);
    //    parameters.Add("Country", company.Country, DbType.String);
    //    using (var connection = _context.CreateConnection())
    //    {
    //        var id = await connection.QuerySingleAsync<int>(query, parameters);
    //        var createdCompany = new Company
    //        {
    //            Id = id,
    //            Name = company.Name,
    //            Address = company.Address,
    //            Country = company.Country
    //        };
    //        return createdCompany;
    //    }
    //}

    /// <summary>
    /// Call store procedure
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public async Task<Company> GetCompanyByEmployeeId(int id)
    //{
    //    var procedureName = "ShowCompanyForProvidedEmployeeId";
    //    var parameters = new DynamicParameters();
    //    parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);
    //    using (var connection = _context.CreateConnection())
    //    {
    //        var company = await connection.QueryFirstOrDefaultAsync<Company>
    //            (procedureName, parameters, commandType: CommandType.StoredProcedure);
    //        return company;
    //    }
    //}

    /// <summary>
    /// Executing Multiple SQL Statements with a Single Query
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public async Task<Company> GetCompanyEmployeesMultipleResults(int id)
    //{
    //    var query = "SELECT * FROM Companies WHERE Id = @Id;" +
    //                "SELECT * FROM Employees WHERE CompanyId = @Id";
    //    using (var connection = _context.CreateConnection())
    //    using (var multi = await connection.QueryMultipleAsync(query, new { id }))
    //    {
    //        var company = await multi.ReadSingleOrDefaultAsync<Company>();
    //        if (company != null)
    //            company.Employees = (await multi.ReadAsync<Employee>()).ToList();
    //        return company;
    //    }
    //}


    /// <summary>
    /// Multiple Mapping
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public async Task<List<Company>> GetCompaniesEmployeesMultipleMapping()
    //{
    //    var query = "SELECT * FROM Companies c JOIN Employees e ON c.Id = e.CompanyId";
    //    using (var connection = _context.CreateConnection())
    //    {
    //        var companyDict = new Dictionary<int, Company>();
    //        var companies = await connection.QueryAsync<Company, Employee, Company>(
    //            query, (company, employee) =>
    //            {
    //                if (!companyDict.TryGetValue(company.Id, out var currentCompany))
    //                {
    //                    currentCompany = company;
    //                    companyDict.Add(currentCompany.Id, currentCompany);
    //                }
    //                currentCompany.Employees.Add(employee);
    //                return currentCompany;
    //            }
    //        );
    //        return companies.Distinct().ToList();
    //    }
    //}

    /// <summary>
    /// Transaction
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //public async Task CreateMultipleCompanies(List<CompanyForCreationDto> companies)
    //{
    //    var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)";
    //    using (var connection = _context.CreateConnection())
    //    {
    //        connection.Open();
    //        using (var transaction = connection.BeginTransaction())
    //        {
    //            foreach (var company in companies)
    //            {
    //                var parameters = new DynamicParameters();
    //                parameters.Add("Name", company.Name, DbType.String);
    //                parameters.Add("Address", company.Address, DbType.String);
    //                parameters.Add("Country", company.Country, DbType.String);
    //                await connection.ExecuteAsync(query, parameters, transaction: transaction);
    //            }
    //            transaction.Commit();
    //        }
    //    }
    //}

    #endregion
}
