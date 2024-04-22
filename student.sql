
-- Procedure to insert a new student
CREATE OR REPLACE PROCEDURE insert_student(
    p_first_name VARCHAR,
    p_last_name VARCHAR,
    p_email VARCHAR,
    p_department VARCHAR,
    p_gender VARCHAR,
    p_phone_number VARCHAR,
    p_address VARCHAR
)
LANGUAGE SQL
AS $$
INSERT INTO students (first_name, last_name, email, department, gender, phone_number, address)
VALUES (p_first_name, p_last_name, p_email, p_department, p_gender, p_phone_number, p_address);
$$;

-- Procedure to update an existing student
CREATE OR REPLACE PROCEDURE update_student(
    p_id INT,
    p_first_name VARCHAR,
    p_last_name VARCHAR,
    p_email VARCHAR,
    p_department VARCHAR,
    p_gender VARCHAR,
    p_phone_number VARCHAR,
    p_address VARCHAR
)
LANGUAGE SQL
AS $$
UPDATE students
SET first_name = p_first_name,
    last_name = p_last_name,
    email = p_email,
    department = p_department,
    gender = p_gender,
    phone_number = p_phone_number,
    address = p_address
WHERE s_id = p_id;
$$;

-- Procedure to delete a student by ID
CREATE OR REPLACE PROCEDURE delete_student(p_id INT)
LANGUAGE SQL
AS $$
DELETE FROM students WHERE s_id = p_id;
$$;

-- Procedure to get all students
CREATE OR REPLACE PROCEDURE get_students()
LANGUAGE SQL
AS $$
SELECT * FROM students;
$$;

-- Procedure to get a student by ID
CREATE OR REPLACE PROCEDURE get_student_by_id(p_id INT)
LANGUAGE SQL
AS $$
SELECT * FROM students WHERE s_id = p_id;
$$;
