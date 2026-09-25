namespace Bank;
// Состояние объектов этого класса нельзя изменить
internal record Transaction(decimal Amount, DateTime Date, string Note);
