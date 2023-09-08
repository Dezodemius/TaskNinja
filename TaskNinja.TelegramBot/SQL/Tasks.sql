create table Responsible
(
    Id     text,
    TaskId text
);

create table Tasks
(
    Id          text,
    Name        text,
    Description text,
    Status      integer
);

create table TaskDiscussion
(
    Id     text,
    TaskId text
);
