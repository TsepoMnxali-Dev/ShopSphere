# 🛒 E-Commerce Backend API

> **A backend-focused E-Commerce API built with C# and ASP.NET Core to showcase my backend development skills, database design, REST API development, and business logic.**

---

## 📌 About

This project is a **backend-only E-Commerce API** developed to demonstrate my ability to design and build a functional backend system.

The API provides functionality for managing products, categories, shopping carts, orders, payments, and reviews.

The main focus of this project was to showcase my understanding of **backend development, relational databases, API design, and e-commerce business logic**.

> **Note:** Authentication and authorization were not implemented in this version, as the focus was on the core backend functionality.

![image alt](https://github.com/TsepoMnxali-Dev/ShopSphere/blob/f9bd6dcd90bdc3161565bf9e8c4f6921cb0dc1bd/ShopSphere%20BackEnd.png)

## 🎥 Demo

<p align="center">
  <a href="https://www.dropbox.com/scl/fi/r834n6mgo4ggmf5g0wk67/ShopSphere-E-Commerce-System.mp4?rlkey=8js1eyufp2wvmhkvr6cd65gjy&st=6o52uxgg&dl=0">
    ▶️ <strong>Watch the CoolRides Demo</strong>
  </a>
</p>


## 🛠️ Technologies

* **C#**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **MySQL**
* **REST API**
* **Swagger / OpenAPI**
* **LINQ**

---

## 🗄️ Main Entities

The backend uses the following main entities:

* **Users**
* **Products**
* **Categories**
* **Carts**
* **Cart Items**
* **Orders**
* **Order Items**
* **Payments**
* **Reviews**

The database uses relationships between these entities through **primary keys and foreign keys**.

---

## 🌐 API Endpoints

### 📦 Products

| Method   | Endpoint             | Description       |
| -------- | -------------------- | ----------------- |
| `GET`    | `/api/products`      | Get all products  |
| `GET`    | `/api/products/{id}` | Get product by ID |
| `POST`   | `/api/products`      | Create a product  |
| `PUT`    | `/api/products/{id}` | Update a product  |
| `DELETE` | `/api/products/{id}` | Delete a product  |

### 🗂️ Categories

| Method   | Endpoint               | Description        |
| -------- | ---------------------- | ------------------ |
| `GET`    | `/api/categories`      | Get all categories |
| `GET`    | `/api/categories/{id}` | Get category by ID |
| `POST`   | `/api/categories`      | Create a category  |
| `PUT`    | `/api/categories/{id}` | Update a category  |
| `DELETE` | `/api/categories/{id}` | Delete a category  |

### 🛒 Cart

| Method   | Endpoint                    | Description          |
| -------- | --------------------------- | -------------------- |
| `GET`    | `/api/cart/{userId}`        | Get user's cart      |
| `POST`   | `/api/cart/add`             | Add product to cart  |
| `PUT`    | `/api/cart/update`          | Update cart quantity |
| `DELETE` | `/api/cart/remove/{itemId}` | Remove cart item     |
| `DELETE` | `/api/cart/clear/{userId}`  | Clear cart           |

### 📋 Orders

| Method | Endpoint                    | Description         |
| ------ | --------------------------- | ------------------- |
| `POST` | `/api/orders`               | Create an order     |
| `GET`  | `/api/orders/{id}`          | Get order by ID     |
| `GET`  | `/api/orders/user/{userId}` | Get user's orders   |
| `PUT`  | `/api/orders/{id}/status`   | Update order status |
| `POST` | `/api/orders/checkout`      | Checkout cart       |

### 💳 Payments

| Method | Endpoint             | Description       |
| ------ | -------------------- | ----------------- |
| `POST` | `/api/payments`      | Create payment    |
| `GET`  | `/api/payments/{id}` | Get payment by ID |
| `PUT`  | `/api/payments/{id}` | Update payment    |

### ⭐ Reviews

| Method   | Endpoint                     | Description         |
| -------- | ---------------------------- | ------------------- |
| `GET`    | `/api/products/{id}/reviews` | Get product reviews |
| `POST`   | `/api/reviews`               | Create review       |
| `PUT`    | `/api/reviews/{id}`          | Update review       |
| `DELETE` | `/api/reviews/{id}`          | Delete review       |

---

## 🧠 Key Backend Features

* Product and category management
* Shopping cart functionality
* Order creation and checkout
* Product stock management
* Order total calculation
* Payment management
* Product reviews
* Relational database design
* RESTful API endpoints
* Swagger API documentation

---

## 🛒 Checkout Logic

When a customer checks out, the backend:

1. Retrieves the customer's cart.
2. Checks product availability.
3. Validates the requested stock quantity.
4. Calculates the order total.
5. Creates the order and order items.
6. Updates product stock.
7. Clears the customer's cart.

---

## 🧪 API Testing

The API can be tested using **Swagger/OpenAPI**, allowing the endpoints and request/response data to be tested directly from the browser.

---

## 🚧 Current Limitations

This version does not include:

* Authentication
* Authorization
* Frontend
* Production payment gateway
* Email notifications

These can be added in future versions.

---

## 🎯 Purpose

This project was created primarily to **showcase my backend development skills** and demonstrate my ability to build an API-driven application with database relationships and real-world business logic.

---

## 👨‍💻 Developer

**Tsepo Mnxali**

Software Engineer
