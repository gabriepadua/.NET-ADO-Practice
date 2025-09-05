using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

public class Repository<TModel> where TModel : class
{
    private readonly SqlConnection _connection;

    public Repository(SqlConnection connection)
    => _connection = connection;

    public IEnumerable<TModel> GetAll()
    => _connection.GetAll<TModel>();

    public TModel Get(int id)
        => _connection.Get<TModel>(id);

    public void Create(TModel tmodel)
    => _connection.Insert<TModel>(tmodel);

    public void Update(TModel tmodel)
    => _connection.Update<TModel>(tmodel);

    public void Delete(TModel tmodel)
    => _connection.Delete<TModel>(tmodel);

    public void Delete(int id)
    {
        var tmodel = _connection.Get<TModel>(id);
        _connection.Delete<TModel>(tmodel);
    }
}