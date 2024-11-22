import { useEffect, useRef, useState } from "react";
import { editTodoAPI, addTodosAPI, delTodosAPI, getTodosAPI } from "../api/todos";

const Todos = () => {
    const [todos, setTodos] = useState([]);
    const [textBtn, setTextBtn] = useState("Them moi");
    const todoRef = useRef([]);

    // Khởi tạo state cho dữ liệu
    const data = [];

    // Sử dụng useEffect để gọi API khi component được mount
    useEffect(() => {
        fetchData();
    }, []);

    // Hàm gọi API để lấy dữ liệu
    const fetchData = async () => {
        setTodos(await getTodosAPI());
    };

    const delTodo = async (id) => {
        if (window.confirm("Nhiem vu khong the khoi phuc, ban co muon xoa khong")) {
            await delTodosAPI(id);
            fetchData();
        }
    }

    const addOrEditTodo = async (event) => {
        event.preventDefault();
        const val = event.target[0].value;
        const id = event.target[1].value;

        if (id) {
            //Update
            await editTodoAPI({
                name: val,
                id: id
            });
            todoRef.current[id].className = "fas fa-edit";

        } else {
            //New
            await addTodosAPI({
                name: val
            })
        }
        fetchData();
    }

    const editTodo = (id) => {
        todoRef?.current.forEach((item) => {
            if (item.getAttribute("data-id") && item.getAttribute("data-id") !== String(id)) {
                item.className = "fas fa-edit";
            }
        });
        const inputName = document.getElementById("name");
        const inputId = document.getElementById("id");
        if (todoRef?.current[id].className === "fas fa-edit") {
            todoRef.current[id].className = "fas fa-user-edit";
            setTextBtn("Cap nhat");
            inputName.value = todoRef.current[id].getAttribute("data-name");
            inputId.value = id;
        } else if (todoRef?.current[id].className === "fas fa-user-edit") {
            todoRef.current[id].className = "fas fa-edit";
            setTextBtn("Them moi");
            inputName.value = "";
            inputId.value = null;
        }
    }

    const onIsCompleteTodo = async (todo) => {
        await editTodoAPI({
            ...todo,
            isComplete: true
        });
        fetchData();
    }

    return (
        <main id="todolist">
            <h1>
                Danh sách
                <span>Việc hôm nay không để ngày mai.</span>
            </h1>
            <ul>
                {
                    todos ? (
                        todos?.map((item, key) => (
                            <li className={item.isComplete ? "done" : ""} key={key} onDoubleClick={() => onIsCompleteTodo(item)}>
                                <span className="label">{item.name}</span>
                                <div className="actions">
                                    <button
                                        className="btn-picto"
                                        type="button"
                                        aria-label="Edit"
                                        title="Edit"
                                        onClick={() => editTodo(item.id)}
                                    >
                                        <i
                                            className="fas fa-edit"
                                            ref={el => todoRef.current[item.id] = el}
                                            data-name={item.name}
                                            data-id={item.id}
                                        />
                                    </button>
                                    <button
                                        className="btn-picto"
                                        type="button"
                                        aria-label="Delete"
                                        title="Delete"
                                        onClick={() => delTodo(item.id)}
                                    >
                                        <i className="fas fa-trash"></i>
                                    </button>
                                </div>
                            </li>
                        )))
                        :
                        <p>Danh sách nhiệm vụ trống.</p>
                }
            </ul>
            <form onSubmit={addOrEditTodo}>
                <label htmlFor="name">Thêm nhiệm vụ mới</label>
                <input type="text" name="name" id="name" placeholder="Tên nhiệm vụ" />
                <input type="hidden" id="id" name="id" placeholder="Mã nhiệm vụ" />
                <button type="submit">{textBtn}</button>
            </form>
        </main>
    );
};

export default Todos;
