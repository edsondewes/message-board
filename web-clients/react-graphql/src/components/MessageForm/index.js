import React, { useEffect, useReducer } from "react";
import { useMutation } from "@apollo/react-hooks";
import { gql } from "apollo-boost";
import { eventBus, MESSAGE_CREATED } from "../../services/eventBus";
import style from "./_style.css";

const ADD_MESSAGE = gql`
  mutation newMessages($message: MessageInput!) {
    createMessage(message: $message) {
      id
      created
      text
    }
  }
`;

const TextLengthLimit = 250;

const initialState = {
  canSubmit: false,
  expanded: false,
  text: "",
};

function reducer(state, action) {
  switch (action.type) {
    case "write":
      return { ...state, canSubmit: action.text.length > 0, text: action.text };
    case "expand":
      return { ...state, expanded: true };
    case "retract":
      return { ...state, expanded: false };
    case "reset":
      return { canSubmit: false, expanded: false, text: "" };
    default:
      throw new Error();
  }
}

function MessageForm() {
  const [state, dispatch] = useReducer(reducer, initialState);
  const [addMessage, { data }] = useMutation(ADD_MESSAGE);

  useEffect(() => {
    if (data) {
      eventBus.emit(MESSAGE_CREATED, data.createMessage);
      dispatch({ type: "reset" });
    }
  }, [data]);

  function onBlur() {
    if (state.text.length === 0) {
      dispatch({ type: "retract" });
    }
  }

  function onChange(event) {
    const currentLength = event.target.value.length;
    if (currentLength <= TextLengthLimit) {
      dispatch({ type: "write", text: event.target.value });
    }
  }

  function onFocus() {
    dispatch({ type: "expand" });
  }

  async function onSubmit(event) {
    event.preventDefault();
    await addMessage({
      variables: {
        message: {
          text: state.text,
        },
      },
    });
  }

  return (
    <form
      onSubmit={onSubmit}
      className={`${style.messageForm} ${state.expanded ? style.expanded : ""}`}
    >
      <textarea
        aria-label="Write what's in your mind"
        onBlur={onBlur}
        onChange={onChange}
        onFocus={onFocus}
        value={state.text}
        placeholder="What's in your mind?"
        rows="1"
      />
      <div className={style.options}>
        <span>
          {state.text.length}/{TextLengthLimit}
        </span>
        <input
          {...(!state.canSubmit ? { disabled: true } : {})}
          className={style.btnSubmit}
          type="submit"
          value="Submit"
        />
      </div>
    </form>
  );
}

export default React.memo(MessageForm);
