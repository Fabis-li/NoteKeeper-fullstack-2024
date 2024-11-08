import { Routes } from '@angular/router';
import { ListagemNotasComponent } from './listar/listagem-notas.component';
import { CadastroNotaComponent } from './cadastrar/cadastro-nota.component';
import { EdicaoNotaComponent } from './editar/edicao-nota.component';
import { ExclusaoNotaComponent } from './excluir/exclusao-nota.component';
import { ListarNotasArquivadasComponent } from './listar-arquivadas/listagem-notas-arquivadas.component';

export const notasRoutes: Routes = [
  {
    path: '',
    redirectTo: 'listar',
    pathMatch: 'full',
  },
  { path: 'listar', component: ListagemNotasComponent },
  { path: 'listar/arquivadas', component: ListarNotasArquivadasComponent },
  { path: 'cadastrar', component: CadastroNotaComponent },
  { path: 'editar/:id', component: EdicaoNotaComponent },
  { path: 'excluir/:id', component: ExclusaoNotaComponent },
];
