<script setup lang="ts">
defineProps({
  title: String,
  btnConfirmText: String,
  btnCancelText: String,
})
</script>

<template>
  <div class="modal fade" id="modal">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">{{ title }}</h5>
        </div>
        <div class="modal-body">
          <slot name="body"></slot>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            {{ btnCancelText }}
          </button>
          <button @click="$emit('modal-action')" type="button" class="btn btn-primary">
            {{ btnConfirmText }}
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
