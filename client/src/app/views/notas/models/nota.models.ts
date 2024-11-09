import { ListarCategoriaViewModel } from '../../categorias/models/categoria.models';

export interface InserirNotaViewModel {
  titulo: string;
  conteudo: string;
  arquivada: boolean;

  categoriaId: string;
}

export interface NotaInseridaViewModel {
  id: string;
  titulo: string;
  conteudo: string;
  arquivada: boolean;

  categoriaId: string;
}

export interface EditarNotaViewModel {
  titulo: string;
  conteudo: string;
  arquivada: boolean;

  categoriaId: string;
}

export interface NotaEditadaViewModel {
  id: string;
  titulo: string;
  conteudo: string;
  arquivada: boolean;

  categoriaId: string;
}

export interface ListarNotaViewModel {
  id: string;
  titulo: string;
  conteudo: string;
  arquivada: boolean;

  categoria: ListarCategoriaViewModel;
}

export interface VisualizarNotaViewModel {
  id: string;
  titulo: string;
  conteudo: string;
  arquivada: boolean;

  categoria: ListarCategoriaViewModel;
}

export interface NotaExcluidaViewModel {}
