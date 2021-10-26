CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS company(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL COMMENT 'Company Name'
)default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS contractor(  
    id int NOT NULL primary key AUTO_INCREMENT,
    name varchar(255) NOT NULL COMMENT 'Contractor Name',
    picture varchar(255) Comment'Contractor Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS job(
id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
contractorId int NOT NULL,
companyId int NOT NULL
) default charset utf8 COMMENT '';

SELECT * FROM accounts;