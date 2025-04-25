CREATE TRIGGER StudentTrigger
ON Studenci
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Historie (Imie, Nazwisko, GrupaID, TypAkcji, Data)
    SELECT 
        i.Imie, 
        i.Nazwisko, 
        i.GrupaID, 
        'edycja', 
        GETDATE()
    FROM inserted i;

    INSERT INTO Historie (Imie, Nazwisko, GrupaID, TypAkcji, Data)
    SELECT 
        d.Imie, 
        d.Nazwisko, 
        d.GrupaID, 
        'usuwanie', 
        GETDATE()
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.ID = d.ID);
END;
