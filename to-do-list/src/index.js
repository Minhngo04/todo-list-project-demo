import React from 'react';
import ReactDOM from 'react-dom/client';
import Todos from './component/Todos.js'
import '@fortawesome/fontawesome-free/css/all.min.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <Todos />
  </React.StrictMode>
);
