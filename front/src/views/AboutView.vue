<template>
  <div class="about">
    <h1>Acerca del Sistema de Gestión</h1>
    <div class="about-content">
      <section class="about-section">
        <h2>Nuestro Proyecto</h2>
        <p>
          El Sistema de Gestión de Productos es una aplicación diseñada para facilitar el control y
          administración de inventarios de manera eficiente y sencilla.
        </p>
      </section>

      <section class="about-section">
        <h2>Tecnologías Utilizadas</h2>
        <p>
          Esta aplicación ha sido desarrollada utilizando Vue.js 3 con TypeScript, implementando una
          arquitectura moderna basada en composables y el patrón de estado global con Pinia.
        </p>
      </section>

      <section class="about-section">
        <h2>Características Principales</h2>
        <ul>
          <li>Gestión completa de productos (crear, editar, eliminar)</li>
          <li>Control de inventario en tiempo real</li>
          <li>Interfaz intuitiva y fácil de usar</li>
          <li>Reportes detallados de existencias</li>
        </ul>
      </section>

      <section class="about-section">
        <h2>Contacto</h2>
        <p>
          Para más información o soporte técnico, no dude en contactar con nuestro equipo de
          desarrollo.
        </p>
        <div class="contact-button">
          <button class="btn btn--primary">Contactar</button>
        </div>
      </section>
    </div>
  </div>
</template>

<style lang="scss">
@use '@/styles/views/about-view.scss';
</style>
