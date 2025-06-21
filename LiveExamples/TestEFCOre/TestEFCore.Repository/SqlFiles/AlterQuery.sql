alter table [UserRole] add column ModifiedOn DateTime2

update [UserRole]  set ModifiedOn = getdate()

alter table [UserRole] alter column ModifiedOn DateTime2 not null



alter table [Role] add column ModifiedOn DateTime2

update [Role]  set ModifiedOn = getdate()

alter table [Role] alter column ModifiedOn DateTime2 not null
