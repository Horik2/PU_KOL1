CREATE TRIGGER StudentTrigger
ON Studenci
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Historie (Imie, Nazwisko, GrupaID, TypAkcji, Data)
    SELECT 
        d.Imie, 
        d.Nazwisko, 
        d.GrupaID, 
        'edycja', 
        GETDATE()
    FROM deleted d
    INNER JOIN inserted i ON d.ID = i.ID;

    INSERT INTO Historie (Imie, Nazwisko, GrupaID, TypAkcji, Data)
    SELECT 
        d.Imie, 
        d.Nazwisko, 
        d.GrupaID, 
        'usuwanie', 
        GETDATE()
    FROM deleted d
    LEFT JOIN inserted i ON d.ID = i.ID
    WHERE i.ID IS NULL;
END;
