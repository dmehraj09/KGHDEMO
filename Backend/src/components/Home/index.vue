<template>
  <div class="row justify-content-between">
    <div class="col col-1">
      <Icon icon="mdi:home" class="svg-9x text-green" />
    </div>
    <div class="">
      <HelloApi :name="name" />
    </div>
    <div class="col-md-auto"></div>   
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import HelloApi  from './HelloApi.vue';

@Component({
  components: {
    HelloApi,
  },
})
export class Home extends Vue {
  @Prop({ default: '' }) name: string; 

}
export default Home;
</script>
