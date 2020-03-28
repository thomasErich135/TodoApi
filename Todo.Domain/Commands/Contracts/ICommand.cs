using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;

namespace Todo.Domain.Commands.Contracts
{
    public interface ICommand : IValidatable
    {
    }
}
