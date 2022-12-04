global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using PortalStore.Domain.Contracts;

// https://dotnetcoretutorials.com/2021/08/19/global-using-statements-in-c10/
// doesn't work 
// maybe because of namespace
namespace PortalStore.Domain.Contracts
{

}
//didn't work
// maybe because of class declaration
// oh god! 🤦‍♂️ there is no global keyword upside there...