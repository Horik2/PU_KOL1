﻿CREATE PROCEDURE AddStudent
    @Imie NVARCHAR(100),
    @Nazwisko NVARCHAR(100),
    @GrupaID INT
AS
BEGIN
    INSERT INTO Studenci (Imie, Nazwisko, GrupaID)
    VALUES (@Imie, @Nazwisko, @GrupaID);
END
