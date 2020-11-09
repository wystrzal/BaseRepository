using System;
using System.Collections.Generic;
using System.Text;

namespace BaseRepository.Exceptions
{
    public class ChangesNotSavedCorrectlyException : Exception
    {
        public ChangesNotSavedCorrectlyException(Type entity) : base($"Could not saved changes correctly in {entity} entity")
        {

        }
    }
}
