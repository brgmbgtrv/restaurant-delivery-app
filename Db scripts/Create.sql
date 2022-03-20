CREATE TABLE UserRoles
(
    [Id] int IDENTITY (1,1),
    [name] varchar(100),
    CONSTRAINT PK_userRoles_Id PRIMARY KEY (Id)
);

CREATE TABLE Users 
(
    [Id] int IDENTITY (1,1),
    [login]	varchar(100),
    [password] varchar(100),
    roleId int,
    CONSTRAINT PK_Users_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_Users_UserRoles_Id FOREIGN KEY (roleId) REFERENCES UserRoles ([Id])
)

CREATE TABLE Discounts
(
    [Id] int IDENTITY (1,1),
    [name] varchar(100),
    [percent] int,
    CONSTRAINT PK_Discounts_Id PRIMARY KEY (Id)
)

CREATE TABLE OrderStatus
(
    [Id] int IDENTITY (1,1),
    [name] varchar(100),
    CONSTRAINT PK_OrderStatus_Id PRIMARY KEY ([Id])
);

CREATE TABLE Orders 
(
    [Id] int IDENTITY (1,1),
    statusId int,
    [address] varchar(300),
    [contact] varchar(100),
    price int,
    discountId int,
    CONSTRAINT PK_Orders_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_Orders_status FOREIGN KEY (statusId) REFERENCES OrderStatus ([Id]),
    CONSTRAINT FK_Orders_discount FOREIGN KEY (discountId) REFERENCES Discounts ([Id])
)

CREATE TABLE OrderToDish 
(
    orderId	int,
    dishId int,
	price int,
	quantity int,
    CONSTRAINT PK_OrderToDish PRIMARY KEY (orderId, dishId),
    CONSTRAINT FK_OrderToDish_order FOREIGN KEY (orderId) REFERENCES Orders([Id])
)



CREATE TABLE IngredientCategory
(
    Id int IDENTITY (1,1),
    category varchar(50),
    price int,
	CONSTRAINT PK_IngredientCategory_Id PRIMARY KEY (Id)
);

CREATE TABLE Ingredient
(
    Id int IDENTITY (1,1),
    ingredient varchar(50),
    ingredientCategory int,
	CONSTRAINT PK_Ingredient_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Ingredient_IngredientCategory_ingredientCategory FOREIGN KEY (ingredientCategory) REFERENCES IngredientCategory (Id)
);

CREATE TABLE DishCategory 
(
    Id int IDENTITY (1,1),
    category varchar(50),
	CONSTRAINT PK_DishCategory_Id PRIMARY KEY (Id)
);

CREATE TABLE Menu 
(
    Id int IDENTITY (1,1),
    dishCategory int,
    [name] varchar(100),
    price int,
	CONSTRAINT PK_Menu_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Menu_DishCategory_dishCategory FOREIGN KEY (dishCategory) REFERENCES DishCategory (Id)
);

CREATE TABLE OrderToConstructorDish 
(
    orderId	int,
    dishId int,
    ingredientId int,
    quantity int,
    CONSTRAINT PK_OrderToConstructor_orserId PRIMARY KEY (orderId, dishId, ingredientId),
    CONSTRAINT FK_OrderToConstructor_Order_orderId FOREIGN KEY (orderId) REFERENCES Orders([Id]),
    CONSTRAINT FK_OrderToConstructor_Menu_dishId FOREIGN KEY (dishId) REFERENCES Menu ([Id]),
    CONSTRAINT FK_OrderToConstructor_Ingredient FOREIGN KEY (ingredientId) REFERENCES Ingredient ([Id])
)

CREATE TABLE Templates 
(
    dishId	int,
    categoryId	int,
    CONSTRAINT PK_template_categories PRIMARY KEY (dishId, categoryId),
    CONSTRAINT FK_template_dish FOREIGN KEY (dishId) REFERENCES Menu ([Id]),
    CONSTRAINT FK_template_catrgory FOREIGN KEY (categoryId) REFERENCES IngredientCategory ([Id])
);

CREATE TABLE DishToIngredient 
(
    dishId int,
    ingredientId int,
	CONSTRAINT PK_DishToIngredient_dishId_ingredientId PRIMARY KEY (dishId, ingredientId),
	CONSTRAINT FK_DishToIngredient_Menu_dishId FOREIGN KEY (dishId) REFERENCES Menu (Id),
	CONSTRAINT FK_DishToIngredient_Ingredient_ingredientId FOREIGN KEY (ingredientId) REFERENCES Ingredient (Id)
);