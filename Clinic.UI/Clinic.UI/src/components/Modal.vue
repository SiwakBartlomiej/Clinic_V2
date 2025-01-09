<script setup lang="ts">
const props = defineProps({
  title: String,
  btnConfirmText: String,
  btnCancelText: String,
})
</script>

<template>
  <div class="modal fade" id="exampleModal">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">{{ title }}</h5>
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
