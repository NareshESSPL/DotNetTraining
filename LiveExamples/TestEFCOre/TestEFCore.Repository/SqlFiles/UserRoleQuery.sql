INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('alice', 'alice123', 1, GETDATE());
INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('bob', 'bobpwd', 1, GETDATE());
INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('carol', 'carolpass', 1, GETDATE());
INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('dan', 'dan321', 0, GETDATE());
INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('eve', 'evepwd', 1, GETDATE());
INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('frank', 'frank789', 1, GETDATE());
INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('grace', 'gracepass', 0, GETDATE());
INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('heidi', 'heidi007', 1, GETDATE());
INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('ivan', 'ivan123', 1, GETDATE());
INSERT INTO[User] (UserName, Password, IsActive, ModifiedOn) VALUES ('judy', 'judysecure', 0, GETDATE());

INSERT INTO[Role] (RoleName) VALUES ('Admin');
INSERT INTO[Role] (RoleName) VALUES ('Manager');
INSERT INTO[Role] (RoleName) VALUES ('User');
INSERT INTO[Role] (RoleName) VALUES ('Guest');
INSERT INTO[Role] (RoleName) VALUES ('Developer');
INSERT INTO[Role] (RoleName) VALUES ('Support');
INSERT INTO[Role] (RoleName) VALUES ('HR');
INSERT INTO[Role] (RoleName) VALUES ('QA');
INSERT INTO[Role] (RoleName) VALUES ('Finance');
INSERT INTO[Role] (RoleName) VALUES ('Intern');

INSERT INTO[UserRole] (UserID, RoleID) VALUES (1, 1);
INSERT INTO[UserRole] (UserID, RoleID) VALUES (1, 2);
INSERT INTO[UserRole] (UserID, RoleID) VALUES (2, 3);
INSERT INTO[UserRole] (UserID, RoleID) VALUES (3, 1);
INSERT INTO[UserRole] (UserID, RoleID) VALUES (4, 4);
INSERT INTO[UserRole] (UserID, RoleID) VALUES (5, 2);
INSERT INTO[UserRole] (UserID, RoleID) VALUES (6, 3);
INSERT INTO[UserRole] (UserID, RoleID) VALUES (7, 1);
INSERT INTO[UserRole] (UserID, RoleID) VALUES (8, 2);
INSERT INTO[UserRole] (UserID, RoleID) VALUES (9, 5);

INSERT INTO[Device] (UserID, DeviceName) VALUES (1, 'iPhone 12');
INSERT INTO[Device] (UserID, DeviceName) VALUES (2, 'Samsung Galaxy S21');
INSERT INTO[Device] (UserID, DeviceName) VALUES (3, 'Google Pixel 6');
INSERT INTO[Device] (UserID, DeviceName) VALUES (4, 'iPad Air');
INSERT INTO[Device] (UserID, DeviceName) VALUES (5, 'Dell XPS 13');
INSERT INTO[Device] (UserID, DeviceName) VALUES (6, 'MacBook Pro');
INSERT INTO[Device] (UserID, DeviceName) VALUES (7, 'Surface Pro 7');
INSERT INTO[Device] (UserID, DeviceName) VALUES (8, 'OnePlus 9');
INSERT INTO[Device] (UserID, DeviceName) VALUES (9, 'ThinkPad X1');
INSERT INTO[Device] (UserID, DeviceName) VALUES (10, 'Realme Pad');


