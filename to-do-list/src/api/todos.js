import axios from "./axios";

const END_POINT = {
    TODOS: "todos"
}

export const getTodosAPI = () => {
    return axios.get(`${END_POINT.TODOS}`);
}

export const delTodosAPI = (id) => {
    return axios.delete(`${END_POINT.TODOS}/${id}`);
}

export const addTodosAPI = (todo) => {
    return axios.post(`${END_POINT.TODOS}`, todo);
}

export const editTodoAPI = (todo) => {
    // Kiểm tra xem todo có chứa id không, nếu không thì trả về lỗi
    if (!todo.id) {
        throw new Error("Todo phải có id để cập nhật");
    }

    // Gọi API với phương thức PUT, URL chứa id để chỉ định nhiệm vụ cần cập nhật
    return axios.put(`${END_POINT.TODOS}/${todo.id}`, todo); // Đảm bảo rằng URL bao gồm id
}
