﻿SELECT a.Id, u.FirstName, u.LastName, u.Email, a.TimeIn, a.TimeOut, a.Comment FROM Users u, Attendance a, Class c WHERE u.Email = a.UserID AND c.Id = a.ClassID AND a.Confirmation is NULL AND DATEPART(YEAR, a.TimeIn) = '" + curYear + "' AND DATEPART(MONTH, a.TimeIn) = '" + curMonth + "' AND DATEPART(DAY, a.TimeIn)= '" + curDay + "'"