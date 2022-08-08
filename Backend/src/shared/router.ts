import Vue from 'vue';
import Router, { Route } from 'vue-router';
import Home from '../components/Home/index.vue';

export enum Routes {
  Home = '/',  
}

Vue.use(Router);



const routes = [
  { path: Routes.Home, component: Home, props: { name: 'Vue' } },
  { path: '*', redirect: '/' },
];

export const router = new Router ({
    mode: 'history',
    linkActiveClass: 'active',
    routes,
});

export const redirect = (path: string) => {
  const externalUrl = path.indexOf('://') >= 0;
  if (!externalUrl) {
      router.push({ path });
  } else {
      location.href = path;
  }
};


