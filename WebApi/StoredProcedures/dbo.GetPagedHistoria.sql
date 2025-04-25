CREATE PROCEDURE GetPagedHistoria
    @Page INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ID, Imie, Nazwisko, GrupaID, TypAkcji, Data
    FROM (
        SELECT *, ROW_NUMBER() OVER (ORDER BY Data DESC) AS RowNum
        FROM Historia
    ) AS T
    WHERE T.RowNum BETWEEN (@Page - 1) * @PageSize + 1 AND @Page * @PageSize;
END
