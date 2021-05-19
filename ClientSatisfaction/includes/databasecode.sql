CREATE TABLE clientsatisfaction (
    id int(10) AUTO_INCREMENT PRIMARY KEY not null,
    clientID text not null,
    businessName varchar(50),
    rating int(5) not null
)

INSERT INTO clientsatisfaction (clientID, businessName, rating)
VALUES ('A00000002', '', '2');