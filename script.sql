CREATE TABLE IF NOT EXISTS Client (
    account varchar(12) PRIMARY KEY NOT NULL,
    name VARCHAR(255)
);


CREATE TABLE IF NOT EXISTS Ordens (
    order_id VARCHAR(36) PRIMARY KEY NOT NULL,
    account VARCHAR(12),
    symbol varchar(10),
    side TINYINT(1),
    qty INT,
    price DECIMAL(6,2),
    create_order_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (account) REFERENCES Client(account)
);


INSERT INTO Client (account, name) VALUES
   ('0002021', 'Julia'),
   ('0002022', 'Pedro'),
   ('0002023', 'Vitor');
