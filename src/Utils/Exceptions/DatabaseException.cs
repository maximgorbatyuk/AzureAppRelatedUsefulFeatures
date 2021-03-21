﻿using System;

namespace Utils.Exceptions
{
    public class DatabaseException : InvalidOperationException
    {
        public DatabaseException(Exception innerException)
            : base("Exception during database command execution", innerException)
        {
        }
    }
}