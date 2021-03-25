using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetOwners();
        Owner GetOwnerByEmail(string email);


        Owner GetOwnerById(int id);
    }
}