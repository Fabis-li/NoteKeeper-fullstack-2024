import { Routes } from "@angular/router";
import { CadastroCategoriaComponent } from "./cadastrar/cadastro-categoria.component";
import { EdicaoCategoriaComponent } from "./editar/edicao-categoria.component";
import { ExclusaoCategoriaComponent } from "./excluir/exclusao-categoria.component";
import { ListagemCategoriasComponent } from "./listar/listagem-categorias.component";

export const categoriasRoutes: Routes = [
  { path: '', redirectTo: 'listar', pathMatch: 'full' },
  { path: 'listar', component: ListagemCategoriasComponent },
  { path: 'cadastrar', component: CadastroCategoriaComponent },
  { path: 'editar/:id', component: EdicaoCategoriaComponent },
  { path: 'excluir/:id', component: ExclusaoCategoriaComponent },
]
