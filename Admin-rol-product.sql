--INGRESO POR BASE DE DATOS

INSERT INTO Users
(IdWeb, [UserName], InsertDate, UpdateDate, IsActive, IdRol, Password, EncryptedPassword)
VALUES
(NEWID(), 'Isabel', GETDATE(), GETDATE(), 1, 2, '456', '456def')

SELECT * FROM Users

INSERT INTO RolType
([NameRol], [Description], IsActive)
VALUES
('Mayorista', 'Precio1', 1)

SELECT * FROM RolType

INSERT INTO Products
([ProductName], [ProductBrand], IdWeb, InsertDate, UpdateDate, IsActive, IsPublic, RawPrice)
VALUES
('Boli', 'Bic', NEWID(), GETDATE(), GETDATE(), 1, 1, 0.55),
('Goma', 'Milan', NEWID(), GETDATE(), GETDATE(), 1, 1, 0.35)

SELECT * FROM Products