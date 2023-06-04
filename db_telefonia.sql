create database Telefonia;
use Telefonia;

create table Usuario(
	idUsuario varchar(36) primary key,
    nome varchar(50),
    telefone varchar(14),
    email varchar(50)
);

create table Contato (
	idContato int primary key auto_increment,
    numeroTelefone varchar(14),
    nomeContato varchar(50),
    idUsuario varchar(36),
    foreign key (idUsuario) references Usuario(IdUsuario)
);

DELIMITER //
CREATE PROCEDURE InserirContato(
    IN p_numeroTelefone VARCHAR(14),
    IN p_nomeContato VARCHAR(50),
    IN p_idUsuario VARCHAR(36)
)
BEGIN
    INSERT INTO Contato (numeroTelefone, nomeContato, idUsuario)
    VALUES (p_numeroTelefone, p_nomeContato, p_idUsuario);
END //


DELIMITER //
CREATE PROCEDURE ObterContatosPorUsuario(
    IN p_idUsuario VARCHAR(36)
)
BEGIN
    SELECT * FROM Contato WHERE idUsuario = p_idUsuario;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE DeletarContato(
    IN p_idContato INT
)
BEGIN
    DELETE FROM Contato WHERE idContato = p_idContato;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE AlterarNomeContato(
    IN p_idContato INT,
    IN p_novoNomeContato VARCHAR(50)
)
BEGIN
    UPDATE Contato SET nomeContato = p_novoNomeContato WHERE idContato = p_idContato;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE InserirUsuario(
    IN p_idUsuario VARCHAR(36),
    IN p_nome VARCHAR(50),
    IN p_telefone VARCHAR(14),
    IN p_email VARCHAR(50)
)
BEGIN
    INSERT INTO Usuario (idUsuario, nome, telefone, email)
    VALUES (p_idUsuario, p_nome, p_telefone, p_email);
END //
DELIMITER ;

call InserirUsuario("13fe5d8f-dd71-4fc5-af1d-d687b3c253f9", "corno manso", "11987654322", "agua@gmail.com");

call InserirContato("11912345678", "joao leao", "13fe5d8f-dd71-4fc5-af1d-d687b3c253f9");