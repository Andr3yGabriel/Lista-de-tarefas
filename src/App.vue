<template>
  <div>
    <!-- Formulário para adicionar tarefa -->
    <q-card class="q-pa-md">
      <q-card-section>
        <q-card-title>
          Adicionar Tarefa
        </q-card-title>
        <q-form @submit.prevent="adicionarTarefa">
          <q-input v-model="novaTarefa.tarefa" label="Tarefa" />
          <q-input v-model="novaTarefa.descrição" label="Descrição" />
          <q-select v-model="novaTarefa.status" label="Status" :options="statusOptions" />
          <q-btn type="submit" label="Adicionar" color="primary"  method="post"/>
        </q-form>
      </q-card-section>
    </q-card>

    <!-- Lista de tarefas -->
    <q-card class="q-pa-md">
      <q-card-section v-if="tarefas.length > 0">
        <q-card-title>
          Lista de Tarefas
        </q-card-title>
        <q-list>
          <q-item v-for="(tarefa, index) in tarefas" :key="index">
            <q-item-section>{{ tarefa.id }}</q-item-section>
            <q-item-section>{{ tarefa.tarefa }}</q-item-section>
            <q-item-section side>{{ tarefa.status }}</q-item-section>
          </q-item>
        </q-list>
      </q-card-section>
      <q-card-section v-else>
        <q-card-title>
          Lista de Tarefas Vazia
        </q-card-title>
      </q-card-section>
    </q-card>

    <!-- Detalhes de uma única tarefa -->
    <q-card v-if="mostrarDetalhes">
      <q-card-section>
        <q-card-title>
          Detalhes da Tarefa
        </q-card-title>
        <q-form @submit.prevent="buscarTarefa">
          <q-input v-model="idTarefa" label="ID da Tarefa" />
          <q-btn type="submit" label="Buscar Tarefa" color="primary" />
        </q-form>
        <q-item v-if="tarefa">
          <q-item-section>{{ tarefa.tarefa }}</q-item-section>
          <q-item-section>{{ tarefa.status }}</q-item-section>
          <q-item-section>{{ tarefa.descrição }}</q-item-section>
        </q-item>
      </q-card-section>
    </q-card>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      novaTarefa: {
        tarefa: '',
        descricao: '',
        status: ''
      },
      tarefas: [],
      statusOptions: ['Fila', 'Parada', 'Em Progresso', 'Concluída'],
      mostrarDetalhes: true,
      idTarefa: '',
      tarefa: null
    };
  },
  methods: {
    async adicionarTarefa() {
      try {
        const response = await axios.post('http://localhost:5171/api/v1/tarefas/adicionar-tarefa', this.novaTarefa);
        console.log(response.data);
        this.novaTarefa = { tarefa: '', descrição: '', status: '' };
        this.listarTarefas();
      } catch (error) {
        console.error('Erro ao adicionar tarefa:', error);
      }
    },
    async listarTarefas() {
      try {
        const response = await axios.get('http://localhost:5171/api/v1/tarefas/listar-tarefas');
        console.log(response.data);
        this.tarefas = response.data;
      } catch (error) {
        console.error('Erro ao listar tarefas:', error);
      }
    },
    async buscarTarefa() {
      try {
        const response = await axios.post(`http://localhost:5171/api/v1/tarefas/${this.idTarefa}/Take`);
        console.log(response.data);
        this.tarefa = response.data;
      } catch (error) {
        console.error('Erro ao buscar tarefa:', error);
      }
    }
  }
};
</script>
