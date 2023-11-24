import React from "react";
import "./TableTp.css";

import editPen from "../../../assets/images/edit-pen.svg";
import trashDelete from "../../../assets/images/trash-delete.svg";

import { Tooltip } from "react-tooltip";

import { dateFormatDbToView } from "../../../Utils/stringFunction";

const TableTp = ({ dados, fnUpdate, fnDelete }) => {
  console.log(dados);
  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--big">
            Título
          </th>
          <th className="table-data__head-title table-data__head-title--big">
            Descrição
          </th>
          <th className="table-data__head-title table-data__head-title--big">
            Tipo de evento
          </th>
          <th className="table-data__head-title table-data__head-title--big">
            Data
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Editar
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Deletar
          </th>
        </tr>
      </thead>

      <tbody>
        {dados.map((e) => {
          return (
            <tr className="table-data__head-row">
              <td className="table-data__data table-data__data--big">
                {e.nomeEvento}
              </td>

              <td
                className="table-data__data table-data__data--big"
                // className='event-card__description'
                data-tooltip-id={e.idEvento}
                data-tooltip-content={e.descricao}
                data-tooltip-place="top"
              >
                <Tooltip id={e.idEvento} className="tooltip" />
                {e.descricao.substr(0, 16)}...
              </td>

              <td className="table-data__data table-data__data--big">
                {e.tiposEvento.titulo}
              </td>

              <td className="table-data__data table-data__data--big">
                {new Date(e.dataEvento).toLocaleDateString()}
              </td>

              <td className="table-data__data table-data__data--little">
                <img
                  className="table-data__icon"
                  src={editPen}
                  onClick={() => {
                    fnUpdate(e);
                  }}
                />
              </td>

              <td className="table-data__data table-data__data--little">
                <img
                  className="table-data__icon"
                  src={trashDelete}
                  onClick={() => {
                    fnDelete(e.idEvento);
                  }}
                />
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default TableTp;
