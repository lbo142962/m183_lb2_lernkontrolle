import React, { useState } from 'react';
import { useMsal } from '@azure/msal-react';
import { INote } from '../interfaces/INote';
import { deleteNote, getNoten, getUsers, postNote, putNote } from '../service/Service';
import { DefaultButton, PrimaryButton, Dialog, DialogFooter, DialogType, TextField, List, Stack } from '@fluentui/react';

export const NotenList = () => {
    const [userId, setUserId] = useState<number>();
    const [noten, setNoten] = useState<INote[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [isCreateDialogOpen, setIsCreateDialogOpen] = useState<boolean>(false);
    const [isUpdateDialogOpen, setIsUpdateDialogOpen] = useState<boolean>(false);
    const [currentNote, setCurrentNote] = useState<INote | null>(null);
    const [newNote, setNewNote] = useState({ value: "", description: "" });

    const { accounts } = useMsal();

    React.useEffect(() => {
        const fetchUserId = async () => {
            const allUsers = await getUsers();
            for (let i = 0; i < allUsers.length; i++) {
                if (!accounts[0]) {
                    break;
                }
                if (allUsers[i].upn === accounts[0].username) {
                    setUserId(allUsers[i].id);
                    break;
                }
            }
        };

        fetchUserId();
    }, [accounts]);

    React.useEffect(() => {
        const fetchNoten = async () => {
            if (!userId) return;
            const allNoten = await getNoten();
            const filteredNoten = allNoten.filter(note => note.userId === userId);
            setNoten(filteredNoten);
            setLoading(false);
        };

        fetchNoten();
    }, [userId]);

    const toggleCreateDialog = () => {
        setIsCreateDialogOpen(!isCreateDialogOpen);
    };

    const toggleUpdateDialog = () => {
        setIsUpdateDialogOpen(!isUpdateDialogOpen);
    };

    const handleCreate = async () => {
        if (userId) {
            const note = await postNote({id: 1, userId: userId, value: newNote.value, description: newNote.description});
            if (!note) {
                console.error("Note was not created");
            }
        }
        setNewNote({ value: "", description: "" });
        toggleCreateDialog();
    };

    const handleOpenUpdateDialog = (note?: INote) => {
        setCurrentNote(note ?? null);
        toggleUpdateDialog();
    };

    const handleUpdate = async () => {
        if (currentNote) {
            if (userId) {
                const note = await putNote(currentNote.id, {id: 1, userId: userId, value: newNote.value, description: newNote.description});
                if (!note) {
                    console.error("Note was not updated");
                }
            }
            setCurrentNote(null);
            toggleUpdateDialog();
        }
    };

    const handleDelete = async (noteId?: number) => {
        if (!noteId) {
            console.error("Note was not deleted");
            return;
        }
        const result = await deleteNote(noteId);
        if (result === "false") {
            console.error("Note was not deleted");
        }
    };

    if (loading) return <p>Loading...</p>;
    // if (!noten.length) return <p>No Noten available.</p>;

    return (
        <div>
            <PrimaryButton onClick={toggleCreateDialog} text="Create New Note" />
            <Dialog
                hidden={!isCreateDialogOpen}
                onDismiss={toggleCreateDialog}
                dialogContentProps={{
                    type: DialogType.largeHeader,
                    title: 'Create New Note'
                }}
                modalProps={{
                    isBlocking: false
                }}
            >
                <TextField label="Value" />
                <TextField label="Description" />
                <DialogFooter>
                    <PrimaryButton onClick={handleCreate} text="Save" />
                    <DefaultButton onClick={toggleCreateDialog} text="Cancel" />
                </DialogFooter>
            </Dialog>
            <Dialog
                hidden={!isUpdateDialogOpen}
                onDismiss={toggleUpdateDialog}
                dialogContentProps={{
                    type: DialogType.largeHeader,
                    title: 'Update Note'
                }}
                modalProps={{
                    isBlocking: false
                }}
            >
                <TextField label="Value" defaultValue={currentNote?.value} />
                <TextField label="Description" defaultValue={currentNote?.description} />
                <DialogFooter>
                    <PrimaryButton onClick={handleUpdate} text="Update" />
                    <DefaultButton onClick={toggleUpdateDialog} text="Cancel" />
                </DialogFooter>
            </Dialog>
            <List
                items={noten}
                onRenderCell={(note, index) => (
                    <Stack horizontal tokens={{ childrenGap: 10 }}>
                        <span>{note?.value} - {note?.description}</span>
                        <span>
                            <DefaultButton text="Edit" onClick={() => handleOpenUpdateDialog(note)} />
                            <DefaultButton text="Delete" onClick={() => handleDelete(note?.id)} />
                        </span>
                    </Stack>
                )}
            />
        </div>
    );
};
